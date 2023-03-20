$(document).ready(function () {
    $('.maskTelefone').inputmask({ mask: ['(99) 9999-9999'] });
    $('.maskCelular').inputmask({ mask: ['(99) 99999-9999'] });

    $('.maskCPF').inputmask({ mask: ['999.999.999-99'] });
    $('.maskCNPJ').inputmask({ mask: ['99.999.999/9999-99'] });

    $('.maskValor').inputmask({ mask: ['"{0:N}", 43239, 11'] });

})