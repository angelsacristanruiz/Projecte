<!DOCTYPE html>
<html>
    <head><meta charset="gb18030">
    	<title></title>
    	<link href="views/css/estilo.css" rel="stylesheet" type="text/css" />
    	<meta name="viewport" content="width=device-width, initial-scale=1" charset="euc-jp">
    	<script src="views/js/funcions.js" type="text/javascript"></script>
    </head>
    <body>
        <div class="container">
            <div class="info">
                <h1>Gestió d'horaris</h1>
            </div>
        </div>
        
        <div class="form">
            <div class="thumbnail">
                <img src="views/img/logo.png" />
            </div>
            
            <form class="login-form" id="formulario" name="formulario" onsubmit="registra(); return false">
                <div id="quitar">
                    <input id="usuari" placeholder="Nom d'usuari" required="" type="text" />
                    <input id="contrasenya" placeholder="Contrasenya" required="" type="password" />
                    <br />
                    
                    <textarea id="comentari" placeholder="Comentari opcional"></textarea>
                    <br />
                    &nbsp;
                    <div id="separa1">
                        <input id="entrada" name="opcion" required="" type="radio" value="Entrada" />
                        <label for="entrada">Entrada</label>
                    </div>
                    
                    <div id="separa2">
                        <input id="salida" name="opcion" required="" type="radio" value="Sortida" />
                        <label for="salida">Sortida</label>
                    </div>
                    <button>Enviar</button>
                </div>
                
                <div id="poner">
                    <textarea id="muestra"> </textarea>
                </div>
            </form>
        </div>
    </body>
</html>
