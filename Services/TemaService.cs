using Microsoft.Maui.Storage;
namespace BragaEventos.Services;
public static class TemaService {
 const string Chave="braga_eventos_tema";
 public static bool Claro=>Preferences.Default.Get(Chave,false);
 public static void Aplicar(){
  if(Application.Current is not { } app)return;
  app.UserAppTheme=Claro?AppTheme.Light:AppTheme.Dark;
  if(app.Windows.FirstOrDefault()?.Page is NavigationPage nav){
   nav.BarBackgroundColor=Claro?Color.FromArgb("#E9F2F7"):Color.FromArgb("#101629");
   nav.BarTextColor=Claro?Color.FromArgb("#152B45"):Colors.White;
  }
 }
 public static void Alternar(){Preferences.Default.Set(Chave,!Claro);Aplicar();}
}