pipeline {
    agent any
    
    environment {
        UNITY_PATH="C:/Program Files/Unity/Hub/Editor/2022.3.4f1/Editor/Unity.exe"
        branch="${json_branch}"
        workingDir="/Users/${machine_user_name}/.jenkins/workspace/${json_branch}"
    }
    
    stages {
        stage('Run Tests') {
            steps {
                sh """cd ${workingDir};\
                    ${UNITY_PATH} -batchmode -projectPath ${workingDir} -runTests -testResults ${workingDir}/CI/results.xml -testPlatform PlayMode -nographics -quit;\
                  """
            }
        }
    }
}