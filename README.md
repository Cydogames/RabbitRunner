# RabbitRunner

SCRIPTS

Empezamos creando un script para el movimiento del jugador (PlayerController), en el cual se va a definir, para comenzar, el salto del personaje:

    · Crear una variable pública de tipo float para la fuerza del salto y otra variable privada de tipo Rigidbody2D, 
      para acceder a sus físicas, llamada "myRigidBody2d".
      
    · Creamos el método privado Awaje() para obtener el componente Rigidbody2D 
    
         --> myRigidBody2d = GetComponent<Rigidbody2D>();
    
    · Creamos el método privado Jump(), cuya función nos permitirá saltar con el personaje mediante la siguiente formula:
    
         --> myRigidBody2d.AddForce(Vector2.up * forceJump, ForceMode2D.Impulse);
         
         * A la física del personaje se le ejerce una fuerza vertical hacia arriba, multiplicado por la fuerza del salto, ejerciendo un impulso con su masa.

    · En el método Update(), colocaremos que si se pulsa el boton que nosotros queramos, se llamará a la función Jump(), 
      para que el personaje salte por cada frame por segundo.
     
Con este código implementado ya deberia saltar nuestro personaje, añadiendo el script al GameObject del personaje como un componente del inspector. Sin embargo, solo nos interesará saltar cuando estemos en el suelo. Por lo que habrá que programar esta función:

    · Antes de nada, es conveniente crear una variable publica de tipo LayerMask para poder acceder a la capa Ground, 
      añadida en el editor de Unity, haciendo referencia al suelo. Dicha variable se llamará groundLayerMask

    · Crear un método de tipo booleano que devolverá true o false, dependiendo si el personaje se encuentra en el suelo o no, llamado isGrounded()
    
    · En dicho método, accederemos a la propiedad del Raycast de la clase de la fisica 2D (Physics2D) mediante la siguiente definición:
    
         --> if (Physics2D.Raycast(this.transform.position, Vector2.down, 1.0f, groundLayerMask.value) { return true } else return false;
         
         * Si el suelo (groundLayerMask.value) está a una distancia inferior a 1.0f por debajo (Vector2.down) 
        de la posición del personaje (this.transform.position), devolver true. En caso contrario, devolver false. */
        
    · De esta manera se completa el método IsGrounded() y se implementa dentro de la función Jump(), 
      definiendo que si el personaje se encuentra en el suelo, que se ejecute la formula de la fuerza del salto, 
      y finalmente que este método Jump() se ejecute al pulsar un boton determinado dentro de la función Update().
