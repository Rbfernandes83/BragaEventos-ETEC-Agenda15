using BragaEventos.Models;
using BragaEventos.Services;
namespace BragaEventos.Views;
public class CalendarioPage:ContentPage{
 DateTime mes=new(DateTime.Today.Year,DateTime.Today.Month,1);
 readonly Label titulo=new(){FontSize=23,FontAttributes=FontAttributes.Bold,HorizontalTextAlignment=TextAlignment.Center};
 readonly Grid grade=new(){ColumnSpacing=4,RowSpacing=4};
 readonly VerticalStackLayout lista=new(){Spacing=8};
 public CalendarioPage(){
  Title="Calendário mensal";
  var anterior=new Button{Text="‹",WidthRequest=55};anterior.Clicked+=(s,e)=>{mes=mes.AddMonths(-1);Atualizar();};
  var proximo=new Button{Text="›",WidthRequest=55};proximo.Clicked+=(s,e)=>{mes=mes.AddMonths(1);Atualizar();};
  var nav=new HorizontalStackLayout{Spacing=12,HorizontalOptions=LayoutOptions.Center,Children={anterior,titulo,proximo}};
  var corpo=new VerticalStackLayout{Padding=18,Spacing=16,Children={nav,grade,new Label{Text="Eventos do mês",FontAttributes=FontAttributes.Bold,FontSize=19},lista}};
  Content=new ScrollView{Content=corpo};Atualizar();
 }
 protected override void OnAppearing(){base.OnAppearing();TemaService.Aplicar();Atualizar();}
 void Atualizar(){
  titulo.Text=mes.ToString("MMMM yyyy",new System.Globalization.CultureInfo("pt-BR"));
  grade.Clear();grade.RowDefinitions.Clear();grade.ColumnDefinitions.Clear();
  for(int i=0;i<7;i++)grade.ColumnDefinitions.Add(new ColumnDefinition{Width=GridLength.Star});
  var dias=new[]{"D","S","T","Q","Q","S","S"};
  for(int c=0;c<7;c++){var label=new Label{Text=dias[c],HorizontalTextAlignment=TextAlignment.Center,FontAttributes=FontAttributes.Bold};grade.Add(label,c,0);}
  var eventos=EventoStore.Listar();
  var deslocamento=(int)mes.DayOfWeek;
  var total=DateTime.DaysInMonth(mes.Year,mes.Month);
  for(int dia=1;dia<=total;dia++){
   var data=mes.AddDays(dia-1);var pos=deslocamento+dia-1;var quantidade=eventos.Count(e=>e.Inicio.Date<=data&&e.Termino.Date>=data);
   var botao=new Button{Text=quantidade>0?$"{dia} • {quantidade}":dia.ToString(),FontSize=12,Padding=new Thickness(1),HeightRequest=45,BackgroundColor=quantidade>0?Color.FromArgb("#087F70"):Color.FromArgb("#334967"),TextColor=Colors.White};
   botao.Clicked+=async(s,e)=>{var nomes=eventos.Where(x=>x.Inicio.Date<=data&&x.Termino.Date>=data).Select(x=>x.Nome).ToList();await DisplayAlert(data.ToString("dd/MM/yyyy"),nomes.Count==0?"Nenhum evento neste dia.":string.Join("\n",nomes),"OK");};
   grade.Add(botao,pos%7,pos/7+1);
  }
  lista.Children.Clear();
  foreach(var ev in eventos.Where(x=>x.Inicio.Year==mes.Year&&x.Inicio.Month==mes.Month).OrderBy(x=>x.Inicio)){
   var b=new Button{Text=$"{ev.Inicio:dd/MM}  •  {ev.Nome}",BackgroundColor=Color.FromArgb("#1D3151"),TextColor=Colors.White};
   b.Clicked+=async(s,e)=>await Navigation.PushAsync(new ResumoPage(ev));lista.Children.Add(b);
  }
  if(lista.Children.Count==0)lista.Children.Add(new Label{Text="Nenhum evento começa neste mês."});
 }
}