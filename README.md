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


## Versão 1.1 — ampliação da Agenda 15
- Cadastro com BindingContext, DateTime, TimeSpan e StringFormat em datas e moeda.
- Atalhos AddDays(+7), AddMonths(+1), AddYears(+1).
- Agenda local com salvar, listar, consultar e excluir eventos (Preferences/JSON).
- Hospedagem opcional: hóspedes, entrada/saída, diária, noites e custo estimado.
- Preferência de lembrete no cadastro: **não** agenda notificações Android nesta versão.
- Custo geral estimado: evento + hospedagem.
- O aplicativo é um protótipo acadêmico; não realiza reservas reais de hotéis, inscrições online ou notificações automáticas.


## Versão 1.2 — melhorias de usabilidade
- Alternância de tema claro/escuro pelo botão ☀ / ☾ na barra superior; escolha mantida no dispositivo.
- Melhor contraste de textos e campos conforme o tema.
- Persistência da agenda em arquivo JSON local com gravação temporária e migração dos dados anteriores.
- Após salvar, o aplicativo abre a agenda; erros de leitura e escrita são informados ao usuário.
- Identificador único por evento, atualização sem duplicação, botão Editar e exclusão.
- Resumo de hospedagem e lembrete com termos em português, ocultando noites quando hospedagem está desligada.
- Notificações Android, pesquisa/filtros, hotéis reais e sincronização online ainda não implementados.
- É necessário compilar e testar no aparelho antes de considerar esta versão validada.
