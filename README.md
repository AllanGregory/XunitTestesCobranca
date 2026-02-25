![.NET](https://img.shields.io/badge/.NET-10-blue)
![Tests](https://img.shields.io/badge/tests-xUnit-green)
![Status](https://img.shields.io/badge/status-learning-orange)

# Motor de Cobrança - Cálculos e Testes de Regras


## 📌 Descrição

Este projeto implementa um motor de cálculo de cobranças financeiras, simulando regras reais utilizadas em sistemas bancários e plataformas de cobrança.

O objetivo é calcular valores atualizados considerando:

- Multa por atraso
- Juros diários
- Descontos percentuais
- Valor total atualizado

O projeto foi desenvolvido com foco em boas práticas de arquitetura, testes unitários e confiabilidade de regras financeiras.


## 🎯 Objetivo

Este projeto foi criado para:

✔ praticar testes unitários com xUnit  
✔ aplicar regras de negócio financeiras reais  
✔ demonstrar organização e qualidade de código  
✔ simular cenários comuns em sistemas de cobrança  
✔ servir como projeto de portfólio profissional


## 🧮 Regras de Negócio

### Multa
- Aplicada apenas quando há atraso.
- Calculada como percentual do valor original.

### Juros
- Calculados por dia de atraso.
- Juros simples baseados no valor original.

### Desconto
- Aplicado sobre o valor atualizado.
- Percentual negativo não permitido.

### Valor atualizado
Valor atualizado = Valor original + Multa + Juros

### Regras de validação
- Desconto negativo gera exceção.
- Valores inválidos são rejeitados.


## 🧱 Estrutura da Solução
```bash
TestesXUnitCobranca.sln
│
├── TestesXUnitCobranca
│   ├── Models
│   └── Services
│
└── TestesXUnitCobranca.Tests
```


### 📦 TestesXUnitCobranca

Contém a lógica de negócio e regras de cálculo.

### 🧪 TestesXUnitCobranca.Tests

Contém testes unitários que garantem a confiabilidade das regras.


## 🛠 Tecnologias Utilizadas

- .NET 10
- C#
- xUnit
- Visual Studio
- Git & GitHub


## 🧪 Testes Unitários

Os testes foram implementados utilizando xUnit para garantir a confiabilidade das regras de negócio.

Os testes cobrem:

✔ cálculo de multa  
✔ cálculo de juros  
✔ aplicação de desconto  
✔ cenários sem atraso  
✔ valores inválidos  
✔ exceções esperadas  
✔ cenários extremos  


### Exemplos testados

- desconto negativo gera exceção
- atraso zero não gera juros
- valores são calculados corretamente
- valor final nunca é negativo


## ▶️ Como Executar os Testes

1. Abrir a solução no Visual Studio
2. Abrir Test Explorer
3. Executar: Run All Tests


## ▶️ Como Executar o Projeto (opcional)

Caso adicione um projeto console para simulação:

dotnet run


## 📊 Exemplo de Cálculo

Valor original: R$ 100,00  
Dias em atraso: 10  
Multa: 2%  
Juros: 1% ao dia  

Multa = 2,00  
Juros = 10,00  

Valor atualizado = R$ 112,00


## 🧠 Decisões Técnicas

- Uso de decimal para precisão financeira.
- Separação da lógica em camada de domínio.
- Retorno via interfaces para encapsulamento.
- Testes unitários para proteger regras críticas.


## 🚀 Melhorias Futuras

- arredondamento bancário configurável
- política de cobrança parametrizável
- geração de demonstrativo detalhado
- suporte a pagamentos parciais
- cobertura de testes ampliada


## 👨‍💻 Autor

Allan Gregory Gilabel
Desenvolvedor Back-end .NET