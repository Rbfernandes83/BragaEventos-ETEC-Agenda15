using System.ComponentModel; using System.Runtime.CompilerServices; namespace BragaEventos.Models;
public class Evento : INotifyPropertyChanged {
 string nome="",local="",categoria="Corporativo"; DateTime inicio=DateTime.Today, termino=DateTime.Today.AddDays(1); int participantes=20; decimal custo=75m;
 public event PropertyChangedEventHandler? PropertyChanged;
 void Mudou([CallerMemberName]string? nomeProp=null){PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(nomeProp)); PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(nameof(Duracao)));PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(nameof(DuracaoTexto)));PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(nameof(CustoTotal)));PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(nameof(CustoTotalTexto)));}
 public string Nome {get=>nome;set{nome=value;Mudou();}} public string Local {get=>local;set{local=value;Mudou();}} public string Categoria {get=>categoria;set{categoria=value;Mudou();}}
 public DateTime Inicio {get=>inicio;set{inicio=value;Mudou();}} public DateTime Termino {get=>termino;set{termino=value;Mudou();}} public int Participantes {get=>participantes;set{participantes=value;Mudou();}} public decimal CustoPorParticipante {get=>custo;set{custo=value;Mudou();}}
 public TimeSpan Duracao => Termino.Date-Inicio.Date; public int Dias => Math.Max(0,Duracao.Days+1); public string DuracaoTexto=>Termino.Date<Inicio.Date?"Datas inválidas":$"{Dias} dia(s) de evento • intervalo de {Duracao.Days} dia(s)";
 public decimal CustoTotal=>Participantes*CustoPorParticipante; public string CustoTotalTexto=>CustoTotal.ToString("C2",new System.Globalization.CultureInfo("pt-BR"));
 public string InicioTexto=>Inicio.ToString("dd/MM/yyyy"); public string TerminoTexto=>Termino.ToString("dd/MM/yyyy"); public string CustoUnitarioTexto=>CustoPorParticipante.ToString("C2",new System.Globalization.CultureInfo("pt-BR"));
}
