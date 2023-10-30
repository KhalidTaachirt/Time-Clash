<?php

header("Access-Control-Allow-Origin: *");

// Current date in Year - Month - Day
$currentDate = date("Y/m/d");

// Post variables from Unity
$playerLocation = $_POST["playerLocation"];  
$playerHealth = $_POST["playerHealth"];  
$usedShards = $_POST["usedShards"]; 
$playedTime = $_POST["playedTime"];

// Check if variables are sent and if they are not empty
if (isset($playerLocation) && isset($playerHealth) && isset($usedShards) && isset($playedTime)) {
    // Make a connection if the variables above were sent with Post
    try {
        require_once("./connection.php"); 

        $databaseConnection = new Connection();
        $conn = $databaseConnection -> make_connection();
        // Placing the insert query in a variable
        $sql = "INSERT INTO Gamemetrics (playerLocation, playerHealth, usedShards, playedTime, Dailysessions_sessionDate) 
                VALUES (:playerLocation, :playerHealth, :usedShards, :playedTime, :currentDate)";

        try {
            // Prepare SQL and bind parameters
            $stmt = $conn->prepare($sql);
            $stmt->bindParam(':playerLocation', $playerLocation);
            $stmt->bindParam(':playerHealth', $playerHealth);
            $stmt->bindParam(':usedShards', $usedShards);
            $stmt->bindParam(':playedTime', $playedTime);
            $stmt->bindParam(':currentDate', $currentDate);
            $stmt->execute();
            // If the execution went well show success message
            echo "Succesfully added game metrics to database";
        } catch (PDOException $e) {
            echo "Unable to send game metrics to database".$e->getMessage();
            exit;
        } finally {
            // Close connection
            $conn = null; 
            echo "Close Connection";
            exit;
        }
    } catch (PDOException $e) {
        echo "Unable to make connection with the database".$e->getMessage();
        exit;
    }
    
} else {
    echo "ACCESS DENIED";
    exit;
}
?>