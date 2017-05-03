# EmailService
EmailService é um serviço de envio e-mail COM interoperável implementado em .NET (c#).

# Objetivo
O objetivo do EmailService é fornecer a desenvolvedores que possuam alguma dificuldade com tecnologias obsoletas, uma maneira de se enviar e-mail. 

Um exemplo, é o envio de e-mail com a conta do emitente do gmail em versões mais antigas do Delphi ou que utilizam versões mais antigas do componente Indy 
(utilizado pelo Delphi). Nestas versões mais antigas, não havia uma maneira de enviar e-mail utilizando o protocolo SSL.

Além de possiblitar o envio de e-mail em outras plataformas, o projeto tem também como objetivo servir de base para estudos de testes de unidade e todos os
aspectos necessários que devem ser aplicados adequadamente para um projeto que seja possível testar (SOLID, POO, Mock e outros).

# Testes
O projeto está com testes de unidade. No entanto, há uma classe de testes (ServicoEmailTest) que possibilita um teste real de envio de e-mail, bastando 
apenas configurar a conta de email do destinatário corretamente.
