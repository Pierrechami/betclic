
# User API - Clean Architecture

## Introduction
Bonjour Nicolas bienvenue sur mon projet de création d’une API REST en suivant les principes de la Clean Architecture. je vais te donner les étapes pour utiliser le projet

## Instructions pour démarrer le projet

### Cloner le projet
```bash
git clone https://github.com/Pierrechami/betclic.git
cd betclic
```

### Restaurer les packages
```bash
dotnet restore
```

### Exécuter l'application
```bash
dotnet run --project Web/Web.csproj
```

L’application est accessible à l’adresse suivante :  
[https://localhost:7169/swagger/index.html](https://localhost:7169/swagger/index.html)

## Exécuter les tests

1. Se déplacer dans le dossier des tests :
   ```bash
   cd UserRepositoryTests
   ```

2. Exécuter les tests avec la commande suivante :
   ```bash
   dotnet test
   ```

## Structure du projet

- **Domain** : Contient les entités de base, comme `User`.
- **Application** : Contient la logique métier.
- **Infrastructure** : Contient les implémentations des repositories.
- **Web** : Contient les contrôleurs et l'API REST.

## Fonctionnalités

- Ajout, modification, suppression et récupération des utilisateurs.
- Validation de l'unicité de l'email lors de l'ajout d'un utilisateur.
- Tests unitaires pour l'ajout, la modification, et la validation de l'email.

## Documentation de l'API

### Endpoints

#### Récupérer tous les utilisateurs

- **Méthode** : `GET`
- **Endpoint** : `/api/user`
- **Description** : Récupère tous les utilisateurs enregistrés.
- **Réponse** : 200 OK

#### Récupérer un utilisateur par ID

- **Méthode** : `GET`
- **Endpoint** : `/api/user/{id}`
- **Description** : Récupère les informations d'un utilisateur spécifique par son ID.
- **Paramètre** :
  - `id` : L'identifiant unique de l'utilisateur.
- **Réponse** : 200 OK / 404 Not Found (si l'utilisateur n'existe pas)

#### Créer un nouvel utilisateur

- **Méthode** : `POST`
- **Endpoint** : `/api/user`
- **Description** : Crée un nouvel utilisateur avec les informations fournies.
- **Réponse** : 201 Created / 400 Bad Request (si l'email est déjà utilisé)

#### Mettre à jour un utilisateur

- **Méthode** : `PUT`
- **Endpoint** : `/api/user/{id}`
- **Description** : Met à jour les informations d'un utilisateur existant.
- **Paramètre** :
  - `id` : L'identifiant unique de l'utilisateur à mettre à jour.
- **Réponse** : 204 No Content / 404 Not Found (si l'utilisateur n'existe pas)

#### Supprimer un utilisateur

- **Méthode** : `DELETE`
- **Endpoint** : `/api/user/{id}`
- **Description** : Supprime un utilisateur spécifique.
- **Paramètre** :
  - `id` : L'identifiant unique de l'utilisateur à supprimer.
- **Réponse** : 204 No Content / 404 Not Found (si l'utilisateur n'existe pas)

## Notes

- Ce projet utilise un repository en mémoire pour stocker les utilisateurs. Par conséquent, aucune base de données n'est nécessaire.
- Les emails des utilisateurs doivent être uniques lors de leur création.
