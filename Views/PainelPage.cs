using BragaEventos.Services;
namespace BragaEventos.Views;
public class PainelPage:ContentPage{
 readonly VerticalStackLayout corpo=new(){Padding=22,Spacing=16};
 public PainelPage(){Title="Painel financeiro";Content=new ScrollView{Content=corpo};}
 protected override void OnAppearing(){base.OnAppearing();TemaService.Aplicar();Atualizar();}
 void Atualizar(){
  var eventos=EventoStore.Listar();
  corpo.Children.Clear();
  corpo.Children.Add(new Label{Text="VISÃO GERAL DOS EVENTOS",FontSize=22,FontAttributes=FontAttributes.Bold});
  Adicionar("Eventos cadastrados",eventos.Count.ToString());
  Adicionar("Eventos futuros",eventos.Count(e=>e.Termino.Date>=DateTime.Today).ToString());
  Adicionar("Participantes previstos",eventos.Sum(e=>e.Participantes).ToString("N0"));
  Adicionar("Custo total dos eventos",eventos.Sum(e=>e.CustoTotal).ToString("C2"));
  Adicionar("Hospedagem estimada",eventos.Sum(e=>e.CustoHospedagem).ToString("C2"));
  Adicionar("Investimento geral estimado",eventos.Sum(e=>e.CustoGeral).ToString("C2"));
  corpo.Children.Add(new Label{Text="Valores estimados dos eventos salvos no dispositivo; não representam pagamentos realizados.",FontSize=12});
 }
 void Adicionar(string titulo,string valor){
  var card=new VerticalStackLayout{Padding=18,Spacing=5,BackgroundColor=Color.FromArgb("#1D3151")};
  card.Children.Add(new Label{Text=titulo,TextColor=Colors.White,FontSize=14});
  card.Children.Add(new Label{Text=valor,TextColor=Color.FromArgb("#61E6C1"),FontSize=25,FontAttributes=FontAttributes.Bold});
  corpo.Children.Add(card);
 }
}