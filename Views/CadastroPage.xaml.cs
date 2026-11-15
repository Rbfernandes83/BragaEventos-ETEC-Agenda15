using BragaEventos.Models; using BragaEventos.Services; namespace BragaEventos.Views;
public partial class CadastroPage : ContentPage {
 readonly Evento evento; bool apareceu;
 public CadastroPage():this(new Evento()){}
 public CadastroPage(Evento existente){evento=existente;InitializeComponent();BindingContext=evento;CategoriaPicker.SelectedItem=evento.Categoria;CustoEntry.Text=evento.CustoPorParticipante.ToString("0.##",System.Globalization.CultureInfo.GetCultureInfo("pt-BR"));DiariaEntry.Text=evento.DiariaHotel.ToString("0.##",System.Globalization.CultureInfo.GetCultureInfo("pt-BR"));}
 protected override async void OnAppearing(){
 base.OnAppearing();TemaService.Aplicar();if(apareceu)return;apareceu=true;
 var cards=new VisualElement[]{HeroCard,IdentidadeCard,DatasCard,InvestimentoCard,HospedagemCard,LembretesCard};
 foreach(var card in cards){card.Opacity=0;card.TranslationY=24;card.Scale=0.98;}
 foreach(var card in cards){
  await Task.WhenAll(card.FadeTo(1,190),card.TranslateTo(0,0,240,Easing.CubicOut),card.ScaleTo(1,240,Easing.CubicOut));
 }
}
 void AlternarTema(object sender,EventArgs e)=>TemaService.Alternar();
 void MaisSeteDias(object sender,EventArgs e){evento.Inicio=evento.Inicio.AddDays(7);evento.Termino=evento.Termino.AddDays(7);}
 void MaisUmMes(object sender,EventArgs e){evento.Inicio=evento.Inicio.AddMonths(1);evento.Termino=evento.Termino.AddMonths(1);}
 void MaisUmAno(object sender,EventArgs e){evento.Inicio=evento.Inicio.AddYears(1);evento.Termino=evento.Termino.AddYears(1);}
 void DiariaMudou(object sender,TextChangedEventArgs e){var s=e.NewTextValue?.Trim().Replace("R$","").Replace(" ","");if(decimal.TryParse(s,System.Globalization.NumberStyles.Number,new System.Globalization.CultureInfo("pt-BR"),out var v)||decimal.TryParse(s,System.Globalization.NumberStyles.Number,System.Globalization.CultureInfo.InvariantCulture,out v))evento.DiariaHotel=Math.Max(0,v);else evento.DiariaHotel=0;}
 async void AbrirAgenda(object sender,EventArgs e)=>await Navigation.PushAsync(new AgendaPage());
 void CategoriaMudou(object sender,EventArgs e){if(CategoriaPicker.SelectedItem is string c)evento.Categoria=c;}
 void DatasMudaram(object sender,DateChangedEventArgs e){}
 void Menos(object sender,EventArgs e){if(evento.Participantes>1)evento.Participantes--;}
 void Mais(object sender,EventArgs e){if(evento.Participantes<100000)evento.Participantes++;}
 void CustoMudou(object sender,TextChangedEventArgs e){var s=e.NewTextValue?.Trim().Replace("R$","").Replace(" ",""); if(decimal.TryParse(s,System.Globalization.NumberStyles.Number,new System.Globalization.CultureInfo("pt-BR"),out var v) || decimal.TryParse(s,System.Globalization.NumberStyles.Number,System.Globalization.CultureInfo.InvariantCulture,out v)) evento.CustoPorParticipante=Math.Max(0,v);else evento.CustoPorParticipante=0;}
 async void GerarResumo(object sender,EventArgs e){if(string.IsNullOrWhiteSpace(evento.Nome)||string.IsNullOrWhiteSpace(evento.Local)){await DisplayAlert("Campos obrigatórios","Informe o nome e o local do evento.","OK");return;}if(evento.Termino.Date<evento.Inicio.Date){await DisplayAlert("Confira as datas","A data de término não pode ser anterior ao início.","OK");return;}if(evento.PrecisaHospedagem && evento.SaidaHotel.Date<=evento.EntradaHotel.Date){await DisplayAlert("Hospedagem","A saída deve ser depois da entrada.","OK");return;}if(evento.CustoPorParticipante<0||evento.Participantes<1){await DisplayAlert("Dados inválidos","Confira participantes e custo.","OK");return;}await SalvarButton.ScaleTo(0.97,90);await SalvarButton.ScaleTo(1,110);await Navigation.PushAsync(new ResumoPage(evento));}
}
