# VR Waiting Room Environment (Unity 6.3 LTS)

Projeto em Unity 6.3 LTS com uma cena de ambiente de sala de espera (low-poly), pensado para VR (Meta Quest) e build Android.

## ✨ Visão geral

A cena simula uma sala de espera completa usando assets prontos (mobília, decoração, estrutura) e um conjunto de skyboxes para ambientação. Ao iniciar a cena, as cadeiras realizam uma animação de entrada — movendo-se de suas posições iniciais e retornando ao lugar original — criando uma experiência imersiva para os clientes. O foco é servir como base para experiências VR (locomoção/interação) rodando em dispositivos Meta Quest via pipeline XR do Unity.

## 📦 Assets utilizados

- Low-Poly Office Set #1 [+140 Models] [VNB]
- AllSky Free - 10 Sky / Skybox Set

## 🧩 VR / XR Stack

O projeto foi configurado para VR com:

- **Meta XR All-in-One SDK** (pacote "guarda-chuva" que agrega os SDKs Meta mais recentes).
- **XR Plug-in Management** (framework do Unity para habilitar providers XR por plataforma, ex.: Android). A configuração "Android → Oculus" (ou equivalente) fica centralizada aqui.

## 🤖 Build alvo (Android / Meta Quest)

- Plataforma alvo: Android (ou perfil Meta Quest quando disponível no Unity 6.x).
- Para configurar/confirmar plataforma e XR no fluxo recomendado pela Meta (Build Profiles + OpenXR quando solicitado), use as orientações oficiais.

## 🪑 Interação Obrigatória — Cadeiras Animadas

O projeto conta com **cadeiras interativas** implementadas em C# (`movimentarCadeiras.cs`).

**Como funciona:**

- Ao iniciar a cena, as cadeiras executam automaticamente uma animação de entrada
- Cada cadeira se move a partir de sua posição original, simulando um movimento de "boas-vindas"
- Após a animação, as cadeiras retornam suavemente ao lugar de origem
- A interação ocorre sem necessidade de input do usuário — é disparada pelo evento de início de cena

## 🗂️ Estrutura de pastas (Assets/)

A estrutura abaixo organiza o projeto por tipo de recurso (arte, áudio, scripts, cena) e por pacotes de terceiros:

| Pasta                                          | O que é / Para que serve                                                                                                                                       |
| ---------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `Animation/`                                   | Clips, controllers (Animator), timelines e assets relacionados a animação — incluindo as animações das cadeiras.                                               |
| `Audio/`                                       | Efeitos sonoros, músicas ambiente, mixers e configurações de áudio da sala de espera.                                                                          |
| `HDRPDefaultResources/`                        | Recursos padrão do HDRP (shaders, materiais e configs geradas/necessárias quando o projeto usa HDRP).                                                          |
| `Materials/`                                   | Materiais customizados do projeto (ex.: paredes, piso, variações da sala de espera).                                                                           |
| `Models/`                                      | Modelos 3D (FBX/OBJ) próprios ou importados (fora dos pacotes de terceiros).                                                                                   |
| `Oculus/`                                      | Conteúdo importado/gerado relacionado ao ecossistema Meta/Oculus (dependendo do SDK/pacotes usados).                                                           |
| `Packages/`                                    | Conteúdo de terceiros mantido dentro do Assets (não confundir com Unity Package Manager). Aqui estão agrupados: `AllSkyFree/`, `VNB - Office Set/`, `XR/` etc. |
| `Packages/XR/Loaders` e `Packages/XR/Settings` | Assets de configuração/carregadores XR que podem ser criados/atualizados conforme o XR Plug-in Management e providers ativos.                                  |
| `Photons/`                                     | Área reservada para Photon (multiplayer/networking).                                                                                                           |
| `Plugins/Android/`                             | Plugins nativos Android (AAR, .so, manifest overrides). Padrão quando há integração com SDKs mobile/VR.                                                        |
| `Prefabs/`                                     | Prefabs do projeto (composição final de objetos da cena: paredes, sala de espera, cadeiras, props, interações).                                                |
| `Scripts/`                                     | Scripts C# do projeto (interações VR, animação das cadeiras, lógica de cena, utilitários).                                                                     |

## 🔗 Link do projeto

[https://github.com/alcidesdemelo-multi/MyFirstProjectMetaVerso](https://github.com/alcidesdemelo-multi/MyFirstProjectMetaVerso)
