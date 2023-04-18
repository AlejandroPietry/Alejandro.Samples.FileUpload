# Abordagens de upload de arquivos
Existem duas abordagens disponiveis para realizar o upload de arquivos no ASP.NET Core.

## Buffering
Nesta abordagem, IFormFile, que é uma representacao C# do arquivo, é usado para transferir, processar e salvar um arquivo no servidor web ou qualquer outro lugar onde voce queira salvar. O arquivo inteiro é lido em um objeto IFormFile, portanto, a quantidade de disco e memória que vai ser requisitado do servidor dependerá da quantidade de upload simultâneos e tamanho dos arquivos.
Qualquer arquivo unico sendo carregado for maior que 64 KB, o arquivo sera movido da memoria para o arquivo temporario no disco. Se os recursos de um aplicativo ou servidor web estiverem sendo esgotados (memoria ram e espaco em disco) devido ao grande tamanho dos arquivos e grande quantidade de uploads simultaneos, deve-se considerar o uso da abordage de streaming.

- Buffer: Eh simples de implementar e pode ser usado para fazer upload de arquivos pequenos.

## Streaming
Nessa abordagem, o arquivo é carregado em uma solicitacao de varias partes e processado ou salvo diretamente pelo aplicativo. Para fazer upload de arquivos, a abordagem de streaming consome menos memoria ou espaco em disco comparado com a abordagem de buffer. O streaming deve ser a abordagem preferida ao carregar arquivos maiores no servidor.

-Streaming: deve ser usado quando estamos enviando arquivos grandes ou quando o numero de envios de arquivos simultaneos é maior. O stream consome menos memoria e disco do servidor.

## O que é multipart/form-data?
O multipart/form-data nada mais é do que um dos cabecalhos de tipo de conteudo do metodo post. Esse tipo de conteudo é usado principalmente para enviar os arquivos como parte da solicitacao (quero dizer que vai o arquivo e outros dados do formulario). Quando esse tipo de conteudo é usado, significa que cada valor é enviado em blocos de dados.

## Considerações Finais
Para configurar tamanho dos arquivos que vai ser feito é soh da uma olhada na classe Program, la configuramos o Kestrel para suportar arquivos de ate 300 MB pois o tamanho padrao suportado é de 50 MB.
