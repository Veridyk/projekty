<!DOCTYPE html>
<html>
<head>
	<title>Administrace API</title>
	<meta name="viewport" content="width=device-width, initial-scale=1.0">
	<link rel="stylesheet" type="text/css" href="//fonts.googleapis.com/css?family=Open+Sans" />
	<link rel="stylesheet" type="text/css" href="style.css">
</head>
<body>
	<div class="login-header">
		<h1>Přihlášení do administrace API</h1>
	</div>
	<div class="contact-form">
            <form action="login.php" method="post">
                <h2>Přihlášení</h2>
                <label>Login</label>
                <input type="text" placeholder="Vyplňte váš login" name="login" required/>
                <label>Heslo</label>
                <input type="text" placeholder="Vyplňte vaše heslo" name="password" required/>
                <br/><br/>
                <button>Odeslat</button>
            </form>
        </div>
</body>
</html>