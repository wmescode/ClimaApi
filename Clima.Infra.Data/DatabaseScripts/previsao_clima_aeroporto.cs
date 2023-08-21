/*
 CREATE TABLE previsao_clima_aeroporto
(
    id BIGINT PRIMARY KEY IDENTITY(1,1), 
    codigo_icao VARCHAR(5) NOT NULL,
    atualizado_em DATETIME NOT NULL,
    pressao_atmosferica INT NOT NULL,
    visibilidade VARCHAR(30) NOT NULL,
    vento INT NOT NULL,
    direcao_vento INT NOT NULL,
    umidade INT NOT NULL,
    condicao VARCHAR(3) NOT NULL,
    condicao_desc VARCHAR(50) NOT NULL,
    temp INT NOT NULL
)
 */