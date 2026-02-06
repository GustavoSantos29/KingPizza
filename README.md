# 🍕 KingPizza (Full Stack)

🇧🇷 **Português** | 🇺🇸 **English**

---

## 🇧🇷 Sobre o Projeto

O **KingPizza** é um projeto de estudo Full Stack desenvolvido para praticar a integração entre **C# (.NET)** e **React Native**.

Este projeto é uma evolução/clone do meu projeto anterior ("KingBurguer"). O objetivo é simular um aplicativo real de delivery, migrando a stack tecnológica para aprender novas arquiteturas.

### 📱 Funcionalidades (Escopo)
O sistema foi desenhado para contar com:
* ✅ Criação de Conta / Login (Autenticação JWT).
* 🚧 Lista de Pedidos (WIP no Mobile).
* 🚧 Carrinho de Compras (WIP no Mobile).
* ✅ Catálogo de Produtos.

> ⚠️ **Status do Mobile:** O aplicativo mobile está em desenvolvimento (**Work In Progress**). As telas de Autenticação e Menu estão implementadas, mas o fluxo de fechamento de pedido e carrinho ainda está sendo construído.

### 🛠️ Tecnologias
* **Backend:** C# (.NET 8), Entity Framework, PostgreSQL.
* **Mobile:** React Native, Expo, TypeScript, NativeWind.

---

## 🚀 Como Rodar

### Pré-requisitos
* .NET SDK.
* Node.js e npm.
* PostgreSQL.

### 1️⃣ Backend (API)
1.  Configure a conexão com o banco no `appsettings.json` na pasta `backend`.
2.  Rode as migrations (se necessário) e inicie a API:
    ```bash
    cd backend
    dotnet run
    ```

### 2️⃣ Mobile (App)
1.  Instale as dependências e rode o projeto:
    ```bash
    cd mobile
    npm install
    npx expo start
    ```

---

## 🇺🇸 About the Project

**KingPizza** is a Full Stack study project focused on **C# (.NET)** and **React Native**.

It is a clone/evolution of a previous project ("KingBurguer"), designed to simulate a real food delivery app while migrating the tech stack to master new tools.

### 📱 Features
* ✅ Account Creation / Login (JWT Auth).
* 🚧 Order List (Mobile WIP).
* 🚧 Shopping Cart (Mobile WIP).
* ✅ Product Catalog.

> ⚠️ **Mobile Status:** The mobile app is a **Work In Progress**. Auth and Menu screens are built, but the Checkout flow is under construction.

### 🛠️ Tech Stack
* **Backend:** C# (.NET 8), Entity Framework, PostgreSQL.
* **Mobile:** React Native, Expo, TypeScript, NativeWind.

---

## 🚀 How to Run

1.  **Backend:** Configure `appsettings.json` and run `dotnet run` in the `backend` folder.
2.  **Mobile:** Run `npm install` and `npx expo start` in the `mobile` folder.
3.  **Database:** Ensure PostgreSQL is running.
