PGUSER="postgres"
PGPASS="postgres"
psql "host=localhost port=5432 user=$PGUSER password=$PGPASS" -f Scripts/RECREATE_PG_DATABASE.sql && \
psql "host=localhost port=5432 dbname=questions_list_test user=$PGUSER password=$PGPASS" -f ../QuestionsList.Infrastructure/Scripts/CREATE_PG_TABLES.sql
