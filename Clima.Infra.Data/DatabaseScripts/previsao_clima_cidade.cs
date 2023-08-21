/*
 CREATE TABLE previsao_clima_cidade
(
    id BIGINT PRIMARY KEY IDENTITY(1,1), 
    codigo_cidade INT NOT NULL,
    estado VARCHAR(2) NOT NULL,
    nome VARCHAR(30) NOT NULL,
    data_atualizacao DATETIME NOT NULL,
    data_previsao_clima DATETIME NOT NULL,
    condicao VARCHAR(2) NOT NULL,
    temperatura_minima SMALLINT NOT NULL,
    temperatura_maxima SMALLINT NOT NULL,
    indice_uv SMALLINT NOT NULL,
    condicao_descricao VARCHAR(50) NOT NULL
)

 
 */