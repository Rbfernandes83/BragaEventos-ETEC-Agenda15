using Android.App;
using Android.Content;
using Android.OS;
using BragaEventos.Models;
namespace BragaEventos.Services;
public static class LembreteAndroid {
 const string Canal="braga_eventos_lembretes";
 public static void Agendar(Evento e){
  if(!e.Lembrete)return;
  var momento=e.Inicio.Date.AddHours(9).AddDays(-1);
  if(momento<=DateTime.Now)return;
  var contexto=Android.App.Application.Context;
  if(Build.VERSION.SdkInt>=BuildVersionCodes.O){
   var manager=(NotificationManager?)contexto.GetSystemService(Context.NotificationService);
   manager?.CreateNotificationChannel(new NotificationChannel(Canal,"Lembretes de eventos",NotificationImportance.Default));
  }
  var intent=new Intent(contexto,typeof(LembreteReceiver));
  intent.PutExtra("nome",e.Nome);
  intent.PutExtra("id",e.Id);
  var codigo=e.Id.GetHashCode()&0x7fffffff;
  var pending=PendingIntent.GetBroadcast(contexto,codigo,intent,PendingIntentFlags.UpdateCurrent|PendingIntentFlags.Immutable);
  var alarm=(AlarmManager?)contexto.GetSystemService(Context.AlarmService);
  var millis=new DateTimeOffset(momento).ToUnixTimeMilliseconds();
  alarm?.Set(AlarmType.RtcWakeup,millis,pending);
 }
}
[BroadcastReceiver(Enabled=true,Exported=false)]
public class LembreteReceiver:BroadcastReceiver{
 public override void OnReceive(Context? context,Intent? intent){
  if(context is null)return;
  var nome=intent?.GetStringExtra("nome")??"Evento";
  var manager=(NotificationManager?)context.GetSystemService(Context.NotificationService);
  if(Build.VERSION.SdkInt>=BuildVersionCodes.O)
   manager?.CreateNotificationChannel(new NotificationChannel("braga_eventos_lembretes","Lembretes de eventos",NotificationImportance.Default));
  var builder=new Notification.Builder(context,Build.VERSION.SdkInt>=BuildVersionCodes.O?"braga_eventos_lembretes":null)
   .SetContentTitle("Braga Eventos — amanhã").SetContentText(nome).SetSmallIcon(Android.Resource.Drawable.IcDialogInfo).SetAutoCancel(true);
  manager?.Notify((intent?.GetStringExtra("id")??nome).GetHashCode()&0x7fffffff,builder.Build());
 }
}