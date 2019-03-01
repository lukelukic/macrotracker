SonarScanner.MSBuild.exe begin /k:"lukelukic_macrotracker" /d:sonar.organization="lukelukic-github" /d:sonar.host.url="https://sonarcloud.io" /d:sonar.login="34b6c1f6584a39a6d15122fa2c228b1a7d510551"

MsBuild.exe /t:Rebuild

SonarScanner.MSBuild.exe end /d:sonar.login="34b6c1f6584a39a6d15122fa2c228b1a7d510551"