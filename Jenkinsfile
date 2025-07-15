pipeline {
    agent any
    
    environment {
        UNITY_PATH = "C:\\Program Files\\Unity\\Hub\\Editor\\2022.3.4f1\\Editor\\Unity.exe"
        repo = "https://github.com/IvanMoreno/ChristmasLearning.git"
        branch = "master"  // Set your branch name
        workingDir = "${WORKSPACE}"
    }
    
    stages {
        stage('Clone Repository') {
            steps {
                bat """
                    echo "Cloning repository..."
                    git clone --branch ${branch} --depth 1 ${repo} "${workingDir}\\${branch}"
                """
            }
        }
        
        stage('Force Unity Library Regeneration') {
            steps {
                bat """
                    echo "Forcing Unity to regenerate project files..."
                    cd "${WORKSPACE}\\${branch}"
                    
                    rem Delete existing Library folder if it exists
                    if exist "Library" rmdir /S /Q "Library"
                    
                    rem Force Unity to reimport everything
                    "${UNITY_PATH}" -batchmode -quit -projectPath "${WORKSPACE}\\${branch}" -importPackages -logFile "${WORKSPACE}\\${branch}\\reimport.log"
                    
                    echo "Reimport log:"
                    if exist "${WORKSPACE}\\${branch}\\reimport.log" type "${WORKSPACE}\\${branch}\\reimport.log"
                """
            }
        }
        
        stage('Run Tests') {
            steps {
                bat """
                    echo "Running Unity tests..."
                    cd "${workingDir}\\${branch}"
                    
                    if not exist "CI" mkdir "CI"
                    
                    "${UNITY_PATH}" -batchmode -projectPath "${workingDir}\\${branch}" -runTests -testResults "${workingDir}\\${branch}\\CI\\results.xml" -testPlatform EditMode -nographics -quit
                """
            }
        }
    }
}