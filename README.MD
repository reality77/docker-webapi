# Mode test

## Construction de l'image

`sudo docker build -t webapi .`

## Execution

- Avant l'éxécution, lancer le container postgresql de test (base vide)

`sudo docker run -it -e POSTGRES_USER=webapi -e POSTGRES_PASSWORD=mypostgrespassword! -p 5432:5432 postgre`

- Exécution de notre container web

`sudo docker run -it -p 8080:80 -e APP_DB_SERVER=10.0.2.15 webapi`

option `-it` pour démarrer en interactif
option `-d`pour démarrer en détaché

- Le serveur web va utiliser la variable d'environnement APP_DB_SERVER pour déterminer le nom du serveur de base de données
- Si la base "sample" n'existe pas, le serveur web va la créé et lancer la migration initiale (voir src/web/Startup.cs : `dbcontext.Database.EnsureCreated();`)


## Test

- http://localhost:8080/api/articles/add?name=toto
- http://localhost:8080/api/articles
- http://localhost:8080/api/articles/1

# Mode déploiement

## Démarrer avec un docker swarm

Pour déployer le swarm :

`sudo docker swarm init`

`sudo docker stack deploy -c docker-compose.dev.yml webstack`

Attention : pour le moment, les données de la base ne sont pas persistentes

Pour le quitter :

`sudo docker swarm leave --force`

