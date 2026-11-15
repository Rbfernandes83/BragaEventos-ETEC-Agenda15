using System.ComponentModel; using System.Runtime.CompilerServices; namespace BragaEventos.Models;
public class Evento : INotifyPropertyChanged {
 string nome="",local="",categoria="Corporativo"; DateTime inicio=DateTime.Today, termino=DateTime.Today.AddDays(1); int participantes=20; decimal custo=75m; bool precisaHospedagem; int hospedes=1; decimal diariaHotel=0m; DateTime entradaHotel=DateTime.Today,saidaHotel=DateTime.Today.AddDays(1); bool lembrete;
 public event PropertyChangedEventHandler? PropertyChanged;
 void Mudou([CallerMemberName]string? nomeProp=null){PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(nomeProp)); PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(nameof(Duracao)));PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(nameof(DuracaoTexto)));PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(nameof(CustoTotal)));PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(nameof(CustoTotalTexto)));PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(nameof(DiasHospedagem)));PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(nameof(CustoHospedagem)));PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(nameof(CustoGeral)));}
 public string Nome {get=>nome;set{nome=value;Mudou();}} public string Local {get=>local;set{local=value;Mudou();}} public string Categoria {get=>categoria;set{categoria=value;Mudou();}}
 public DateTime Inicio {get=>inicio;set{inicio=value;Mudou();}} public DateTime Termino {get=>termino;set{termino=value;Mudou();}} public int Participantes {get=>participantes;set{participantes=value;Mudou();}} public decimal CustoPorParticipante {get=>custo;set{custo=value;Mudou();}}
 public bool PrecisaHospedagem {get=>precisaHospedagem;set{precisaHospedagem=value;Mudou();}}
 public int Hospedes {get=>hospedes;set{hospedes=value;Mudou();}}
 public decimal DiariaHotel {get=>diariaHotel;set{diariaHotel=value;Mudou();}}
 public DateTime EntradaHotel {get=>entradaHotel;set{entradaHotel=value;Mudou();}}
 public DateTime SaidaHotel {get=>saidaHotel;set{saidaHotel=value;Mudou();}}
 public bool Lembrete {get=>lembrete;set{lembrete=value;Mudou();}}
 public int DiasHospedagem => Math.Max(0,(SaidaHotel.Date-EntradaHotel.Date).Days);
 public decimal CustoHospedagem => PrecisaHospedagem?Hospedes*DiariaHotel*DiasHospedagem:0m;
 public decimal CustoGeral => CustoTotal+CustoHospedagem;
 public TimeSpan Duracao => Termino.Date-Inicio.Date; public int Dias => Math.Max(0,Duracao.Days+1); public string DuracaoTexto=>Termino.Date<Inicio.Date?"Datas inválidas":$"{Dias} dia(s) de evento • intervalo de {Duracao.Days} dia(s)";
 public decimal CustoTotal=>Participantes*CustoPorParticipante; public string CustoTotalTexto=>CustoTotal.ToString("C2",new System.Globalization.CultureInfo("pt-BR"));
 public string InicioTexto=>Inicio.ToString("dd/MM/yyyy"); public string TerminoTexto=>Termino.ToString("dd/MM/yyyy"); public string CustoUnitarioTexto=>CustoPorParticipante.ToString("C2",new System.Globalization.CultureInfo("pt-BR"));
}
