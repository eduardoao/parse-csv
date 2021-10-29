# parse-csv

 //Retirar as colunas:
    #- id
    #- ip

    #Renomear:
    #- nome -> name
    #- email -> email
    #- data_aniversario -> birthdate

    Campos nome e sobrenome devem ser contatenados com espaço, ex:
    #- John + ' ' + Doe

    Datas devem ser convertidas para formato ISO, ex:
    #27/03/1989 -> 1989-03-27
    #Deve filtrar todas as linhas onde a pessoa for menor de 18 anos.
    #Salvar um CSV com as especificações acima.
