$(document).ready( function() {
   /* Executa a requisição quando o campo CEP perder o foco */
   $('#cep').blur(function(){
           /* Configura a requisição AJAX */
           $.ajax({
                url : 'consultar_cep.php', /* URL que será chamada */ 
                type : 'POST', /* Tipo da requisição */ 
                data: 'cep=' + $('#cep').val(), /* dado que será enviado via POST */
                dataType: 'json', /* Tipo de transmissão */
                success: function(data){
                    if(data.sucesso == 1){
                        $('#rua').val(data.rua);
                        $('#bairro').val(data.bairro);
                        $('#cidade').val(data.cidade);
                        $('#estado').val(data.estado);
 
                        $('#numero').focus();
                    }
                }
           });   
   return false;    
   })
});

  function DataHora(evento, objeto){
  var keypress=(window.event)?event.keyCode:evento.which;
  campo = eval (objeto);
  if (campo.value == '00/00/0000 00:00:00')
  {
    campo.value=""
  }
 
  caracteres = '0123456789';
  separacao1 = '/';
  separacao2 = ' ';
  separacao3 = ':';
  conjunto1 = 2;
  conjunto2 = 5;
  conjunto3 = 10;
  conjunto4 = 13;
  conjunto5 = 16;
  if ((caracteres.search(String.fromCharCode (keypress))!=-1) && campo.value.length < (19))
  {
    if (campo.value.length == conjunto1 )
    campo.value = campo.value + separacao1;
    else if (campo.value.length == conjunto2)
    campo.value = campo.value + separacao1;
    else if (campo.value.length == conjunto3)
    campo.value = campo.value + separacao2;
    else if (campo.value.length == conjunto4)
    campo.value = campo.value + separacao3;
    else if (campo.value.length == conjunto5)
    campo.value = campo.value + separacao3;
  }
  else
    event.returnValue = false;
}