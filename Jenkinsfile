def ver = BUILD_NUMBER
pipeline {
    agent {
        label 'windows01'
    }
    stages {
        stage ('cleanWS-checkout-lookup') {
            steps {
                cleanWs()
                checkout scm
            }
        }

      stage('SonarQube analysis') {
            steps {
                withSonarQubeEnv('SonarMSBuild') {
                    bat 'dotnet sonarscanner begin /key:k8-dotnet /name:hris-recruitmentapi-kubernetes /version:1.0'
                    bat 'dotnet restore'
                    bat 'dotnet build'
                    bat 'dotnet sonarscanner end'
                }
            }
        }
      stage ('Test') {
            steps {
                bat 'dotnet test'
            }
        }


       
        

        stage('docker-build-and-push-image-on-branch') {
            agent {
                label 'jenkins-linux-01'
            }
            when {
                branch 'master'
            }
            steps {
                script {
                    try {
                        print '***** building and pushing image to Nexus repository *****'
                        def dockerImageWithTag = 'k8-dotnet'
                        sh 'whoami'
                        sh "docker build --build-arg JAR_VERSION=\'1.0\' --build-arg APP_NAME=\'k8-dotnet\' -t ${dockerImageWithTag} . --network=host"
                        sh 'echo "${NEXUS_PASSWORD}" | docker login -u ${NEXUS_USER} ${NEXUS_HOST}/repository/docker-nonprod/ --password-stdin'
                        sh "docker tag ${dockerImageWithTag} ${NEXUS_DOCKER_TAG}/${dockerImageWithTag}:${ver}"
                        sh "docker push ${NEXUS_DOCKER_TAG}/${dockerImageWithTag}:${ver}"
                        sh "docker rmi -f ${dockerImageWithTag} ${NEXUS_DOCKER_TAG}/${dockerImageWithTag}:${ver}"
                    }
                     catch (err) {
                        error(err.message)
                        print '***** Error while building/pushing image *****'
                     }
                }
            }
        }

        stage('DeployImage') {
            agent {
                label 'jenkins-linux-01'
            }
            steps {
                cleanWs()
                checkout scm
                sh 'echo ${WORKSPACE}'
               sh '''set +x && cd ${WORKSPACE}/resources/ && chmod 777 env_kube.sh '''
			   sh "sed -i 's/tagversion/'$ver'/g' ${WORKSPACE}/resources/env_kube.sh"			   
			   sh '''set +x && cd ${WORKSPACE}/resources/ && ./env_kube.sh '''			   
               sh '''set +x && cd ${WORKSPACE}/resources/ && ansible-playbook nexus_kube.yaml '''
            }
        }
    }
	 post {
        always {
         script {
          if (GIT_BRANCH == 'master'){
               emailext attachLog: true,
               to: 'kenanibabu.tadepalli@valuelabs.com ,cc:sudhakar.pulavarthi@valuelabs.com,cc:akshay.a@valuelabs.com',
               body: "${currentBuild.currentResult}: Job ${env.JOB_NAME} build ${env.BUILD_NUMBER}\n ",
               recipientProviders: [developers(), requestor()],
               subject: "Jenkins Build ${currentBuild.currentResult}: Job ${env.JOB_NAME}"
       }}
               }
           }
	    
}
