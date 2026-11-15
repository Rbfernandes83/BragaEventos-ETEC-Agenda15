# Braga Eventos — ETEC Agenda 15
Aplicativo de cadastro de eventos em **C# / .NET MAUI**. Projeto separado da Agenda 14 Hotel Braga.

## Requisitos atendidos
- Model `Evento` com `INotifyPropertyChanged`, associada às páginas via `BindingContext`.
- Nome, início, término, participantes, local, categoria e custo por participante.
- Duração calculada usando `DateTime` e `TimeSpan` (contagem inclusiva dos dias do evento).
- Total = participantes × custo unitário, formatado em pt-BR.
- Página de resumo com `Binding` e `StringFormat` para datas.
- Validação, botões +/−, interface em camadas, sombras e transições suaves.

## Como compilar sem MAUI instalado no notebook
1. Crie um repositório público `BragaEventos-ETEC-Agenda15` no GitHub.
2. Envie os arquivos preservando as pastas.
3. Em **Actions**, selecione **Compilar Braga Eventos Agenda 15** e **Run workflow**.
4. Baixe o artefato APK após compilação verde e teste no Android.

## Entrega
Anexar link do repositório e PDF com capturas do cadastro e resumo após testar no aparelho.
