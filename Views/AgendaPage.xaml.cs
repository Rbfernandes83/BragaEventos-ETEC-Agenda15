using BragaEventos.Models;
using BragaEventos.Services;
namespace BragaEventos.Views;
public partial class AgendaPage:ContentPage{
 public AgendaPage(){InitializeComponent();}
 protected override void OnAppearing(){base.OnAppearing();TemaService.Aplicar();Carregar();}
 void AlternarTema(object sender,EventArgs e)=>TemaService.Alternar();
 async void AbrirCalendario(object sender,EventArgs e)=>await Navigation.PushAsync(new CalendarioPage());
 async void AbrirPainel(object sender,EventArgs e)=>await Navigation.PushAsync(new PainelPage());
 void FiltroMudou(object sender,EventArgs e)=>Carregar();
 void BuscaMudou(object sender,TextChangedEventArgs e)=>Carregar();
 void Carregar(){try{var lista=EventoStore.Listar();if(Filtro?.SelectedIndex==1)lista=lista.Where(e=>e.Termino.Date>=DateTime.Today).ToList();else if(Filtro?.SelectedIndex==2)lista=lista.Where(e=>e.Termino.Date<DateTime.Today).ToList();var busca=Busca?.Text?.Trim();if(!string.IsNullOrWhiteSpace(busca))lista=lista.Where(e=>(e.Nome??"").Contains(busca,StringComparison.OrdinalIgnoreCase)||(e.Local??"").Contains(busca,StringComparison.OrdinalIgnoreCase)||(e.Categoria??"").Contains(busca,StringComparison.OrdinalIgnoreCase)).ToList();Eventos.ItemsSource=lista.OrderBy(e=>e.Inicio).ToList();}catch(Exception ex){Eventos.ItemsSource=new List<Evento>();MainThread.BeginInvokeOnMainThread(async()=>await DisplayAlert("Erro na agenda","Não foi possível carregar os eventos: "+ex.Message,"OK"));}}
 async void Editar(object sender,EventArgs e){if(sender is Button {CommandParameter:Evento ev})await Navigation.PushAsync(new CadastroPage(ev));}
 async void VerResumo(object sender,EventArgs e){if(sender is Button {CommandParameter:Evento ev})await Navigation.PushAsync(new ResumoPage(ev));}
 async void Excluir(object sender,EventArgs e){if(sender is Button {CommandParameter:Evento ev} && await DisplayAlert("Excluir evento",$"Excluir {ev.Nome}?","Excluir","Cancelar")){try{EventoStore.Excluir(ev);Carregar();}catch(Exception ex){await DisplayAlert("Erro ao excluir",ex.Message,"OK");}}}
}