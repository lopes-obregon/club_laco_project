// Importando o modelo de Lacador
import Lacador from "../models/LacadorModel.js";

$(function() {
    $("#inscricaoForm").on("submit", function(e) {
        e.preventDefault();

        // Captura os dados do formulário
        const categorias_lista = $('#addcategoria option').map(function() {
            return $(this).val();
        }).get();

        const dados_lacador = {
            nome: $("#nome").val(),
            classe: $('input[name="radiogroup1"]:checked').val(),
            equipe: $("#equipe").val(),
            tem_irmao: $('input[name="irmaogp1"]:checked').val(),
            categorias: categorias_lista,
        };

        const lacador = new Lacador(
            dados_lacador.nome,
            dados_lacador.classe,
            dados_lacador.equipe,
            dados_lacador.tem_irmao,
            dados_lacador.categorias
        );

        console.log(lacador);
    });
});