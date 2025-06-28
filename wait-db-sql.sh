#!/bin/bash
echo "Aguardando o SQL Server iniciar..."

# Loop até conseguir conectar à porta 1433 do container `db`
until nc -z db 1433; do
  echo "Aguardando o banco..."
  sleep 2
done

echo "Banco disponível. Iniciando aplicação..."
exec dotnet desafio-web.dll