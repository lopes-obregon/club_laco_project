export default class Lacador {
    constructor(nome = "", classe = "", equipe = "", tem_irmao = "", categorias = []) {
        this._nome = nome;
        this._classe = classe;
        this._equipe = equipe;
        this._tem_irmao = tem_irmao;
        this._categorias = categorias;
    }

    set nome(nome) {
        this._nome = nome;
    }
    get nome() {
        return this._nome;
    }

    set classe(classe) {
        this._classe = classe;
    }
    get classe() {
        return this._classe;
    }

    set equipe(equipe) {
        this._equipe = equipe;
    }
    get equipe() {
        return this._equipe;
    }

    set tem_irmao(tem_irmao) {
        this._tem_irmao = tem_irmao;
    }
    get tem_irmao() {
        return this._tem_irmao;
    }

    set categorias(categorias) {
        this._categorias = categorias;
    }
    get categorias() {
        return this._categorias;
    }
}
