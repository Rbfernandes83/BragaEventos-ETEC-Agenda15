<div align="center">

# 📅 Braga Eventos

### Planeje com estilo. Organize com precisão.

**Aplicativo Android de gerenciamento de eventos desenvolvido em C# com .NET MAUI.**

![Versão](https://img.shields.io/badge/vers%C3%A3o-1.3-22b8a8?style=for-the-badge)
![Plataforma](https://img.shields.io/badge/plataforma-Android-3DDC84?style=for-the-badge&logo=android&logoColor=white)
![Tecnologia](https://img.shields.io/badge/.NET_MAUI-10.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Projeto](https://img.shields.io/badge/ETEC-Agenda_15-23395B?style=for-the-badge)

**[Funcionalidades](#-funcionalidades) · [Tecnologias](#-tecnologias) · [Como instalar](#-como-instalar-no-android) · [Estrutura](#-estrutura-do-projeto) · [Entrega](#-contexto-acadêmico)**

</div>

---

## ✨ Sobre o projeto

O **Braga Eventos** é um aplicativo acadêmico para planejar, organizar e acompanhar eventos diretamente no celular. Ele reúne cadastro, cálculo automático de custos, agenda mensal, resumo financeiro e ferramentas de compartilhamento em uma interface com **tema claro/escuro**, cartões visuais e animações suaves.

Foi desenvolvido para a **Agenda 15 da disciplina Desenvolvimento de Sistemas II, do curso Técnico em Desenvolvimento de Sistemas da ETEC**, com foco em **BindingContext**, atualização dinâmica de dados e cálculos com `DateTime` e `TimeSpan`.

> **Status:** versão 1.3 compilada e testada em dispositivo Android. Cadastro, persistência, busca, filtros, calendário, painel financeiro, compartilhamento, mapas, PDF e exibição de imagens foram verificados manualmente. **A entrega efetiva de notificações automáticas ainda não foi validada.**

## 🚀 Funcionalidades

| Recurso | Descrição |
| --- | --- |
| 📝 **Cadastro de eventos** | Nome, categoria, local, início, término, participantes e custo individual |
| ⚡ **Cálculos em tempo real** | Duração e custo total atualizados com o preenchimento |
| 🗓️ **Agenda e calendário mensal** | Eventos salvos, consulta por dia e navegação entre meses |
| 🔎 **Busca e filtros** | Pesquisa por nome, local ou categoria; separação entre futuros e realizados |
| ✏️ **Edição e exclusão** | Atualização e remoção dos eventos cadastrados |
| 💰 **Painel financeiro** | Participantes e valores estimados dos eventos e hospedagem |
| 🏨 **Hospedagem opcional** | Estimativa de diárias, hóspedes e custo adicional |
| 🖼️ **Imagem personalizada** | Seleção de fotografia da galeria para cada evento |
| 📍 **Localização** | Abertura da pesquisa do local no Google Maps |
| 📤 **Compartilhamento** | Envio dos detalhes pelo menu nativo, incluindo WhatsApp |
| 📄 **Exportação em PDF** | Geração de resumo simples do evento |
| 🔔 **Lembretes Android** | Agendamento local opcional, sujeito às permissões e restrições do sistema |
| 🎨 **Personalização** | Tema claro/escuro e efeito de entrada em cascata |

### 💡 Exemplo de cálculo

Para um evento com **30 participantes** e **R$ 100,00 por participante**:

```text
30 participantes × R$ 100,00 = R$ 3.000,00
```

O valor é calculado automaticamente. Quando a hospedagem é habilitada, o aplicativo acrescenta sua estimativa ao custo geral.

## 📱 Telas do aplicativo

- **Cadastro:** identificação do evento, datas, participantes, investimento, hospedagem e lembretes.
- **Resumo:** informações gerais, programação, custos, fotografia e ações de compartilhamento.
- **Minha agenda:** eventos salvos, busca, filtros, edição e exclusão.
- **Calendário mensal:** indicação dos dias com eventos.
- **Painel financeiro:** visão consolidada de participantes e investimentos estimados.

**Galeria de capturas:** os prints reais do APK serão adicionados após a organização da documentação de entrega. Não foram incluídas imagens ilustrativas para não confundir com o aplicativo instalado.

## 🛠️ Tecnologias

- **C# e .NET 10 / .NET MAUI:** desenvolvimento da interface e lógica do aplicativo.
- **XAML:** construção das páginas de cadastro, agenda e resumo.
- **`BindingContext` e `INotifyPropertyChanged`:** atualização dinâmica de dados.
- **`DateTime` e `TimeSpan`:** cálculo da duração dos eventos.
- **JSON no armazenamento privado do Android:** persistência local dos cadastros.
- **APIs do Android e MAUI Essentials:** notificações, escolha de imagens, mapas e compartilhamento.
- **GitHub Actions:** compilação automatizada do APK.

## 🗂️ Estrutura do projeto

```text
BragaEventos/
├── .github/workflows/      # Compilação do APK
├── Models/                 # Modelo Evento e propriedades dinâmicas
├── Services/               # Persistência, tema, PDF e integrações
├── Views/                  # Cadastro, resumo, agenda, calendário e painel
├── Platforms/Android/      # Configurações e recursos Android
├── Resources/              # Ícone e tela de abertura
├── App.xaml
└── BragaEventos.csproj
```

## ⬇️ Como instalar no Android

1. Acesse a aba **[Actions](https://github.com/Rbfernandes83/BragaEventos-ETEC-Agenda15/actions)**.
2. Abra uma execução bem-sucedida do fluxo **Compilar Braga Eventos Agenda 15**.
3. Em **Artifacts**, baixe **BragaEventos-Agenda15-APK**.
4. Extraia o arquivo ZIP e instale o APK no Android, autorizando a instalação dessa origem quando solicitado.
5. Abra **Braga Eventos** e faça um cadastro de teste.

> **Atenção:** o arquivo gerado pelo workflow é um APK de teste acadêmico. Instale somente arquivos provenientes deste repositório e de execuções confiáveis. O workflow é iniciado manualmente pela opção **Run workflow**.

### Compilação

O workflow `.github/workflows/android.yml` utiliza **Windows**, instala o **.NET 10** e o workload **MAUI Android**, executa `dotnet publish` em modo Release e disponibiliza o APK como artefato da execução.

## 🧪 Testes realizados

Os seguintes fluxos foram verificados manualmente em aparelho Android:

- Cadastro e cálculo automático de valores.
- Salvamento dos eventos, inclusive após fechar e reabrir o aplicativo.
- Pesquisa, filtros de eventos futuros e realizados.
- Calendário mensal e listagem do evento por data.
- Painel financeiro com valores esperados.
- Geração de PDF e compartilhamento pelo WhatsApp.
- Pesquisa do local no Google Maps.
- Exibição da fotografia selecionada no resumo.

**Ainda requer validação:** disparo real de notificações e persistência da fotografia após reiniciar o aplicativo. A permissão de notificações deve estar habilitada no Android.

## 📚 Contexto acadêmico

**Curso:** Técnico em Desenvolvimento de Sistemas — ETEC  
**Disciplina:** Desenvolvimento de Sistemas II  
**Atividade:** Agenda 15 — Mostrando dados dinâmicos com BindingContext  
**Desenvolvedor:** Rogério Braga Fernandes  
**Projeto:** Braga Eventos — versão 1.3

O aplicativo demonstra vinculação de dados, propriedades observáveis, cálculos automáticos, navegação entre telas e persistência local. Os recursos adicionais ampliam a experiência prática do projeto.

## ℹ️ Limitações

O Braga Eventos é um **protótipo acadêmico**. Os valores são estimativas, não comprovantes de pagamento. O PDF é um resumo informativo, não um documento fiscal. O aplicativo não realiza inscrições, reservas de hospedagem ou sincronização com o Google Agenda. Os dados ficam armazenados localmente no dispositivo; não há conta online nem backup em nuvem. As notificações podem depender de permissões e configurações de economia de bateria do Android.

---

<div align="center">

**Braga Eventos · Agenda 15 · ETEC · 2026**

*Desenvolvido para transformar conceitos de programação em uma experiência Android funcional.*

</div>
