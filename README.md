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


## Versão 1.3 — recursos adicionados ao código (ainda sem validação do APK)
- Calendário mensal navegável com indicadores de eventos e consulta por dia.
- Notificações locais Android: lembrete para 9h do dia anterior ao evento, quando habilitado e permitido pelo sistema; não há sincronização na nuvem.
- Filtros por eventos futuros/realizados e busca por nome/local/categoria.
- Compartilhamento do resumo pelo menu nativo (WhatsApp, e-mail etc., se instalados).
- Abertura do local no aplicativo de mapas via link de pesquisa.
- Geração e compartilhamento de PDF simples do resumo usando Android PdfDocument.
- Painel financeiro de estimativas de custo e participantes.
- Seleção de imagem da galeria, com cópia para o armazenamento privado do aplicativo.
- Efeito cascata na tela de cadastro e temas claro/escuro.

**Pendente:** compilar no GitHub Actions, instalar e validar no Android. O lembrete depende da permissão de notificações e pode sofrer atrasos conforme o sistema Android. O PDF é um resumo simples, não um comprovante fiscal. A foto é armazenada localmente e não é incluída no PDF.
