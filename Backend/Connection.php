<?php
    class Connection {
        function make_connection(){
            // Database connection details
            $servername = "localhost";
            $username = "";
            $password = "";
            $schema = "";

            try {
                // Create PDO instance
                $conn = new PDO("mysql:host=$servername;dbname=$schema", $username, $password);
                $conn->setAttribute(PDO::ATTR_EMULATE_PREPARES, false);
                $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
                // Show success message if connection is successful
                echo "Connected Succesfully";
            } catch (PDOException $e) {
                // Show error code when connection fails
                echo "Connection failed: " . $e->getMessage();
                exit;
            }       

            return $conn;
        }
    }
?>