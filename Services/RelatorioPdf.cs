using BragaEventos.Models;
using Android.Graphics;
using Android.Graphics.Pdf;
using Microsoft.Maui.ApplicationModel.DataTransfer;
namespace BragaEventos.Services;
public static class RelatorioPdf {
 public static async Task Exportar(Evento e){
  var path=Path.Combine(FileSystem.CacheDirectory,"BragaEventos-"+e.Id+".pdf");
  using(var doc=new PdfDocument()){
   var info=new PdfDocument.PageInfo.Builder(595,842,1).Create();
   var page=doc.StartPage(info);
   var canvas=page.Canvas;
   using var paint=new Paint{AntiAlias=true,Color=Android.Graphics.Color.Rgb(20,42,64),TextSize=16};
   int y=70;
   foreach(var line in EventoExtras.Texto(e).Split('\n')){
    if(y>780)break;
    paint.TextSize=y==70?24:16;
    canvas.DrawText(line,40,y,paint);y+=39;
   }
   doc.FinishPage(page);
   using var stream=File.Create(path);doc.WriteTo(stream);
  }
  await Share.Default.RequestAsync(new ShareFileRequest{Title="Exportar PDF do evento",File=new ShareFile(path)});
 }
}