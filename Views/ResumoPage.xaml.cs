using BragaEventos.Models; using BragaEventos.Services; namespace BragaEventos.Views; public partial class ResumoPage:ContentPage {public ResumoPage(Evento evento){InitializeComponent();BindingContext=evento;}protected override async void OnAppearing(){base.OnAppearing();TemaService.Aplicar();Opacity=0;TranslationY=18;await Task.WhenAll(this.FadeTo(1,350),this.TranslateTo(0,0,400,Easing.CubicOut));}async void SalvarAgenda(object sender,EventArgs e){
 if(BindingContext is not Evento evento)return;
 try{
  EventoStore.Salvar(evento);
  await DisplayAlert("Evento salvo","O evento foi salvo. A agenda será aberta agora.","OK");
  await Navigation.PushAsync(new AgendaPage());
 }catch(Exception ex){await DisplayAlert("Erro ao salvar","Não foi possível salvar o evento: "+ex.Message,"OK");}
 }
void AlternarTema(object sender,EventArgs e)=>TemaService.Alternar(); async void Voltar(object sender,EventArgs e)=>await Navigation.PopAsync();}