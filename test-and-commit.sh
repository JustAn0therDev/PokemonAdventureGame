OUTPUT=$(dotnet test)

SUCCESS=0

while read -r LINE; do
	echo $LINE
    if [[ $LINE == *"Aprovado"* ]] || [[ $LINE == *"Passed"* ]]
	then
		SUCCESS=1
		break
    fi

done <<< "$OUTPUT"

if [[ $SUCCESS == 1 ]]
then
	read -p "Coloque sua mensagem de commit: " COMMIT
	git add .
	git commit -m "$COMMIT"
else
	echo "Não é possível realizar o commit pois um ou mais testes não passaram. Por favor, verifique o(s) projeto(s) de teste e tente novamente."
fi

echo $SUCCESS
