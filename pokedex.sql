Create DataBase pokedex

use pokedex

create table Pokemon(
idPokemon int identity(1,1) primary key not null,
imgPokemon varchar(max),
nombre varchar(50),
TipoPrimarioId int,
TipoSecundarioId int,
RegionId int,

constraint FK_Pokemons_Regiones_RegionId foreign key(RegionId) references Region(idRegion),
constraint FK_Pokemons_TiposPrimarios_TipoPrimarioId foreign key(TipoPrimarioId) references TipoPrimario(idTipoPrimario),
constraint FK_Pokemons_TiposPrimarios_TipoSecundarioId foreign key(TipoSecundarioId) references TipoSecundario(idTipoSecundario)
)

create table Region(
idRegion int identity(1,1) primary key not null,
Nombre varchar(50)
)

create table TipoPrimario(
idTipoPrimario int identity(1,1) primary key not null,
Nombre varchar(50)
)

create table TipoSecundario(
idTipoSecundario int identity(1,1) primary key not null,
Nombre varchar(50)
)

drop table Pokemon
drop table Region
drop table TipoPrimario
drop table TipoSecundario

select * from Pokemon
select * from TipoPrimario
select * from TipoSecundario
select * from Region