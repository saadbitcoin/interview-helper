PGUSER="postgres"
PGPASS="postgres"
psql "host=localhost port=5432 user=$PGUSER password=$PGPASS" -f Scripts/CREATE_PG_DATABASE.sql && \
psql "host=localhost port=5432 dbname=test_interview user=$PGUSER password=$PGPASS" -f Scripts/CREATE_PG_TABLES.sql
