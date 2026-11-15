using BragaEventos.Models;
using BragaEventos.Services;
namespace BragaEventos.Views;
public partial class AgendaPage:ContentPage{
 public AgendaPage(){InitializeComponent();}
 protected override void OnAppearing(){base.OnAppearing();TemaService.Aplicar();Carregar();}
 void AlternarTema(object sender,EventArgs e)=>TemaService.Alternar();
 void Carregar(){try{Eventos.ItemsSource=EventoStore.Listar().OrderBy(e=>e.Inicio).ToList();}catch(Exception ex){Eventos.ItemsSource=new List<Evento>();MainThread.BeginInvokeOnMainThread(async()=>await DisplayAlert("Erro na agenda","Não foi possível carregar os eventos: "+ex.Message,"OK"));}}
 async void Editar(object sender,EventArgs e){if(sender is Button {CommandParameter:Evento ev})await Navigation.PushAsync(new CadastroPage(ev));}
 async void VerResumo(object sender,EventArgs e){if(sender is Button {CommandParameter:Evento ev})await Navigation.PushAsync(new ResumoPage(ev));}
 async void Excluir(object sender,EventArgs e){if(sender is Button {CommandParameter:Evento ev} && await DisplayAlert("Excluir evento",$"Excluir {ev.Nome}?","Excluir","Cancelar")){try{EventoStore.Excluir(ev);Carregar();}catch(Exception ex){await DisplayAlert("Erro ao excluir",ex.Message,"OK");}}}
}