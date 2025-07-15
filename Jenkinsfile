pipeline {
    agent any
    
    environment {
        UNITY_PATH = "C:\\Program Files\\Unity\\Hub\\Editor\\2022.3.4f1\\Editor\\Unity.exe"
    }
    
    stages {
        stage('Run Tests') {
            steps {
                bat '''
                    echo "Current workspace: %WORKSPACE%"
                    dir "%WORKSPACE%"
                    
                    if not exist "%WORKSPACE%\\CI" mkdir "%WORKSPACE%\\CI"
                    
                    "%UNITY_PATH%" -batchmode -projectPath "%WORKSPACE%" -runTests -testResults "%WORKSPACE%\\CI\\results.xml" -testPlatform PlayMode -nographics -quit
                '''
            }
        }
    }
}