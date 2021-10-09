pipeline {
  agent {
    node {
      label 'slave-01'
    }

  }
  stages {
    stage('Build') {
      steps {
        sh 'Building'
      }
    }

    stage('Test') {
      steps {
        echo '123'
      }
    }

    stage('Deploy') {
      steps {
        sleep 5
      }
    }

  }
  environment {
    a = '1'
  }
}