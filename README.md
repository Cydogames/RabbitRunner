# RabbitRunner
 
 SCRIPT "PlayerController"
 
 Para que el conejo pueda moverse debemos programar el salto y el movimiento horizontal
 
 Para el salto se crea una función privada llamada Jump(), en la cual se va a establecer la siguiente ecuación:
 
    myRigidbody2d.AddForce(Vector2.up * jumpForce * ForceMode2D.Impulse);
    
    (Dirreción del vector hacia donde se ejercerá una fuerza "arriba" * la fuerza de salto * un impulso de fuerza usando la masa del objeto)
    

