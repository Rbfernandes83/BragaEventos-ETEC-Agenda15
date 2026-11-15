using BragaEventos.Models;
using BragaEventos.Services;
namespace BragaEventos.Views;
public partial class AgendaPage:ContentPage{
 public AgendaPage(){InitializeComponent();}
 protected override void OnAppearing(){base.OnAppearing();Eventos.ItemsSource=EventoStore.Listar().OrderBy(e=>e.Inicio).ToList();}
 async void VerResumo(object sender,EventArgs e){if(sender is Button {CommandParameter:Evento ev})await Navigation.PushAsync(new ResumoPage(ev));}
 async void Excluir(object sender,EventArgs e){if(sender is Button {CommandParameter:Evento ev} && await DisplayAlert("Excluir evento",$"Excluir {ev.Nome}?","Excluir","Cancelar")){EventoStore.Excluir(ev);Eventos.ItemsSource=EventoStore.Listar().OrderBy(x=>x.Inicio).ToList();}}
}