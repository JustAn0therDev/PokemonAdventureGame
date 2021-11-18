OUTPUT=$(dotnet test)
RESULT=0

while read -r LINE; do
	echo $LINE
    if [[ $LINE == *"Aprovado"* ]] || [[ $LINE == *"Passed"* ]]
	then
		RESULT=1
		break
	elif [[ $LINE == *"MSB1003"* ]]
	then
		RESULT=2
		break
    fi
done <<< "$OUTPUT"

if [[ $RESULT == 1 ]]
then
	echo "Todos os testes passaram. Commit pode ser feito de forma segura."
elif [[ $RESULT == 2 ]]
then
	echo "Este projeto não possui testes."
else
	echo "Não é possível realizar commit pois alguns dos testes não passaram. Por favor, verifique o(s) projeto(s) de teste e tente novamente."
fi
