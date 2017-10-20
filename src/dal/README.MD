# Projet dal

## Présentation

Ce projet représente la DAL contenant le contexte de notre base de données applicative appdb (nom du service postgre dans docker-compose)

Pour pouvoir utiliser les commande `dotnet ef`, ajouter `--startup-project ../dal_init/` à la fin de chaque commande

Exemple :

`dotnet ef dbcontext info --startup-project ../dal_init/`

## Création de la migration initiale

`dotnet ef migrations add Initialisation --startup-project ../dal_init/`

## Environnement de debug

Lancer un container : cela va créé un user `sample` et une base de données du même nom

`docker run -d -e POSTGRES_USER=sample -e POSTGRES_PASSWORD=mypostgrespassword! --name appdb -p 5432:5432 postgres`

Et lancer la commande pour mettre à jour la base de données 

`dotnet ef database update --startup-project ../dal_init/`