pipeline {
    agent any
    
    environment {
        UNITY_PATH = "C:\\Program Files\\Unity\\Hub\\Editor\\2022.3.4f1\\Editor\\Unity.exe"
        WORKING_DIR = "C:\\Users\\MSI\\.jenkins\\workspace"
    }
    
    stages {
        stage('Run Tests') {
            steps {
                bat '''
                    cd "%WORKING_DIR%"
                    "%UNITY_PATH%" -batchmode -projectPath "%WORKING_DIR%" -runTests -testResults "%WORKING_DIR%\\CI\\results.xml" -testPlatform PlayMode -nographics -quit
                '''
            }
        }
    }
}