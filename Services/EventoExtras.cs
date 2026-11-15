using BragaEventos.Models;
using Microsoft.Maui.ApplicationModel.DataTransfer;
namespace BragaEventos.Services;
public static class EventoExtras {
 public static string Texto(Evento e)=>$"BRAGA EVENTOS\n{e.Nome}\nCategoria: {e.Categoria}\nLocal: {e.Local}\nInício: {e.Inicio:dd/MM/yyyy}\nTérmino: {e.Termino:dd/MM/yyyy}\nParticipantes: {e.Participantes}\nCusto por participante: {e.CustoPorParticipante:C2}\nCusto do evento: {e.CustoTotal:C2}\nHospedagem: {e.HospedagemStatus}\nTotal geral: {e.CustoGeral:C2}";
 public static Task Compartilhar(Evento e)=>Share.Default.RequestAsync(new ShareTextRequest{Title="Compartilhar evento",Text=Texto(e)});
 public static async Task AbrirMapa(Evento e){
  if(string.IsNullOrWhiteSpace(e.Local))throw new InvalidOperationException("Informe o local do evento.");
  await Launcher.Default.OpenAsync(new Uri("https://www.google.com/maps/search/?api=1&query="+Uri.EscapeDataString(e.Local)));
 }
 public static async Task EscolherImagem(Evento e){
  var foto=await MediaPicker.Default.PickPhotoAsync();
  if(foto is null)return;
  var dir=Path.Combine(FileSystem.AppDataDirectory,"imagens");Directory.CreateDirectory(dir);
  var destino=Path.Combine(dir,e.Id+".jpg");
  await using var origem=await foto.OpenReadAsync();
  await using var arquivo=File.Create(destino);
  await origem.CopyToAsync(arquivo);
  e.ImagemPath=destino;
 }
}