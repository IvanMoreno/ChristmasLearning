pipeline {
    agent any
    
    environment {
        UNITY_PATH="C:/Program Files/Unity/Hub/Editor/2022.3.4f1/Editor/Unity.exe"
        workingDir="C:/Users/MSI/.jenkins/workspace"
    }
    
    stages {
        stage('Run Tests') {
            steps {
                bat """cd ${workingDir};\
                    ${UNITY_PATH} -batchmode -projectPath ${workingDir} -runTests -testResults ${workingDir}/CI/results.xml -testPlatform PlayMode -nographics -quit;\
                  """
            }
        }
    }
}