using System.Text.Json;
using BragaEventos.Models;
using Microsoft.Maui.Storage;
namespace BragaEventos.Services;
public static class EventoStore {
 const string Chave="braga_eventos_agenda15";
 public static List<Evento> Listar(){
  try {return JsonSerializer.Deserialize<List<Evento>>(Preferences.Default.Get(Chave,"[]"))??new();}
  catch{return new();}
 }
 public static void Salvar(Evento evento){
  var lista=Listar();
  lista.Add(new Evento{Nome=evento.Nome,Local=evento.Local,Categoria=evento.Categoria,Inicio=evento.Inicio,Termino=evento.Termino,Participantes=evento.Participantes,CustoPorParticipante=evento.CustoPorParticipante,PrecisaHospedagem=evento.PrecisaHospedagem,Hospedes=evento.Hospedes,DiariaHotel=evento.DiariaHotel,EntradaHotel=evento.EntradaHotel,SaidaHotel=evento.SaidaHotel,Lembrete=evento.Lembrete});
  Preferences.Default.Set(Chave,JsonSerializer.Serialize(lista));
 }
 public static void Excluir(Evento evento){var lista=Listar();var i=lista.FindIndex(e=>e.Nome==evento.Nome&&e.Inicio==evento.Inicio&&e.Local==evento.Local);if(i>=0){lista.RemoveAt(i);Preferences.Default.Set(Chave,JsonSerializer.Serialize(lista));}}
}