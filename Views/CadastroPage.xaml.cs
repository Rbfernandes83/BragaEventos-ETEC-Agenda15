using BragaEventos.Models; namespace BragaEventos.Views;
public partial class CadastroPage : ContentPage {
 readonly Evento evento=new(); bool apareceu;
 public CadastroPage(){InitializeComponent();BindingContext=evento;}
 protected override async void OnAppearing(){base.OnAppearing();if(apareceu)return;apareceu=true;Opacity=0;TranslationY=22;await Task.WhenAll(this.FadeTo(1,450),this.TranslateTo(0,0,500,Easing.CubicOut));}
 void CategoriaMudou(object sender,EventArgs e){if(CategoriaPicker.SelectedItem is string c)evento.Categoria=c;}
 void DatasMudaram(object sender,DateChangedEventArgs e){}
 void Menos(object sender,EventArgs e){if(evento.Participantes>1)evento.Participantes--;}
 void Mais(object sender,EventArgs e){if(evento.Participantes<100000)evento.Participantes++;}
 void CustoMudou(object sender,TextChangedEventArgs e){var s=e.NewTextValue?.Trim().Replace("R$","").Replace(" ",""); if(decimal.TryParse(s,System.Globalization.NumberStyles.Number,new System.Globalization.CultureInfo("pt-BR"),out var v) || decimal.TryParse(s,System.Globalization.NumberStyles.Number,System.Globalization.CultureInfo.InvariantCulture,out v)) evento.CustoPorParticipante=Math.Max(0,v);else evento.CustoPorParticipante=0;}
 async void GerarResumo(object sender,EventArgs e){if(string.IsNullOrWhiteSpace(evento.Nome)||string.IsNullOrWhiteSpace(evento.Local)){await DisplayAlert("Campos obrigatórios","Informe o nome e o local do evento.","OK");return;}if(evento.Termino.Date<evento.Inicio.Date){await DisplayAlert("Confira as datas","A data de término não pode ser anterior ao início.","OK");return;}if(evento.CustoPorParticipante<0||evento.Participantes<1){await DisplayAlert("Dados inválidos","Confira participantes e custo.","OK");return;}await SalvarButton.ScaleTo(0.97,90);await SalvarButton.ScaleTo(1,110);await Navigation.PushAsync(new ResumoPage(evento));}
}
