using System.Text.Json;
using BragaEventos.Models;
using Microsoft.Maui.Storage;
namespace BragaEventos.Services;
public static class EventoStore {
 static readonly string Caminho=Path.Combine(FileSystem.AppDataDirectory,"eventos.json");
 static readonly JsonSerializerOptions Opcoes=new(){WriteIndented=true,PropertyNameCaseInsensitive=true};
 public static List<Evento> Listar(){
  if(!File.Exists(Caminho))return Migrar();
  return JsonSerializer.Deserialize<List<Evento>>(File.ReadAllText(Caminho),Opcoes)??new();
 }
 static List<Evento> Migrar(){
  var antigo=Preferences.Default.Get("braga_eventos_agenda15","[]");
  var lista=JsonSerializer.Deserialize<List<Evento>>(antigo,Opcoes)??new();
  Gravar(lista);return lista;
 }
 static void Gravar(List<Evento> lista){
  var temp=Caminho+".tmp";
  File.WriteAllText(temp,JsonSerializer.Serialize(lista,Opcoes));
  File.Move(temp,Caminho,true);
 }
 public static void Salvar(Evento evento){
  var lista=Listar();
  if(string.IsNullOrWhiteSpace(evento.Id))evento.Id=Guid.NewGuid().ToString("N");
  var i=lista.FindIndex(e=>e.Id==evento.Id);
  if(i>=0)lista[i]=evento;else lista.Add(evento);
  Gravar(lista);
 }
 public static void Excluir(Evento evento){
  var lista=Listar();
  lista.RemoveAll(e=>e.Id==evento.Id);
  Gravar(lista);
 }
}