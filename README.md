# ImageEdit

Biblioteca .NET para edição e identificação de imagens, baseada em ImageMagick e preparada para integração com OutSystems External Libraries.

## Requisitos

- .NET SDK 10.0 ou superior
- Sistema operativo compatível com .NET 10

## Estrutura

- `ImageEdit/`: biblioteca principal
- `ImageEdit.UnitTests/`: testes unitários
- `ImageEdit.sln`: solução Visual Studio/.NET
- `.github/workflows/`: workflows de testes e release

## Funcionalidades

A biblioteca disponibiliza os seguintes métodos:

- `Crop`: recorta uma imagem a partir de uma posição e de dimensões específicas.
- `Resize`: redimensiona uma imagem para caber nas dimensões máximas indicadas, preservando a proporção.
- `Identify`: devolve a largura e a altura da imagem.

## Compilar e testar

Na raiz do repositório, executar:

```bash
dotnet restore ImageEdit.sln
dotnet build ImageEdit.sln --configuration Release
dotnet test ImageEdit.sln --configuration Release
```

Os testes criam imagens PNG em memória e validam os métodos `Crop`, `Resize` e `Identify` sem depender de ficheiros externos.

## Dependências principais

- [Magick.NET](https://github.com/dlemstra/Magick.NET)
- [OutSystems External Libraries SDK](https://www.nuget.org/packages/OutSystems.ExternalLibraries.SDK)
- xUnit, para os testes unitários

## CI/CD

Os workflows em `.github/workflows/` executam os testes, recolhem cobertura de código e, no workflow de release, publicam o artefacto quando é criada uma release/tag compatível.
