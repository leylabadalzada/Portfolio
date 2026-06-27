using Portfolio.Core.Enums;

namespace Portfolio.Service.Extensions
{
    public static class SkillTypeExtensions
    {
        public static string GetIcon(this SkillType skill)
        {
            return skill switch
            {
                // Programming Languages
                SkillType.CSharp => "devicon-csharp-plain",
                SkillType.Java => "devicon-java-plain",
                SkillType.Python => "devicon-python-plain",
                SkillType.JavaScript => "devicon-javascript-plain",
                SkillType.TypeScript => "devicon-typescript-plain",
                SkillType.PHP => "devicon-php-plain",
                SkillType.Go => "devicon-go-original-wordmark",
                SkillType.Rust => "devicon-rust-original",
                SkillType.Kotlin => "devicon-kotlin-plain",
                SkillType.Swift => "devicon-swift-plain",
                SkillType.C => "devicon-c-plain",
                SkillType.Cpp => "devicon-cplusplus-plain",

                // Backend
                SkillType.DotNet => "devicon-dot-net-plain",
                SkillType.AspNetCore => "devicon-dotnetcore-plain",
                SkillType.NodeJs => "devicon-nodejs-plain",
                SkillType.SpringBoot => "devicon-spring-plain",
                SkillType.Django => "devicon-django-plain",
                SkillType.Flask => "devicon-flask-original",
                SkillType.Laravel => "devicon-laravel-original",

                // Frontend
                SkillType.Html => "devicon-html5-plain",
                SkillType.Css => "devicon-css3-plain",
                SkillType.Bootstrap => "devicon-bootstrap-plain",
                SkillType.TailwindCss => "devicon-tailwindcss-plain",
                SkillType.React => "devicon-react-original",
                SkillType.Angular => "devicon-angularjs-plain",
                SkillType.VueJs => "devicon-vuejs-plain",
                SkillType.NextJs => "devicon-nextjs-original",

                // Databases
                SkillType.SqlServer => "devicon-microsoftsqlserver-plain",
                SkillType.PostgreSql => "devicon-postgresql-plain",
                SkillType.MySql => "devicon-mysql-plain",
                SkillType.MongoDb => "devicon-mongodb-plain",
                SkillType.Redis => "devicon-redis-plain",
                SkillType.Oracle => "devicon-oracle-original",

                // Cloud & DevOps
                SkillType.Docker => "devicon-docker-plain",
                SkillType.Kubernetes => "devicon-kubernetes-plain",
                SkillType.Azure => "devicon-azure-plain",
                SkillType.Aws => "devicon-amazonwebservices-original",
                SkillType.GoogleCloud => "devicon-googlecloud-plain",
                SkillType.Jenkins => "devicon-jenkins-line",
                SkillType.GitHubActions => "devicon-githubactions-plain",

                // Tools
                SkillType.Git => "devicon-git-plain",
                SkillType.GitHub => "devicon-github-original",
                SkillType.GitLab => "devicon-gitlab-plain",
                SkillType.Postman => "devicon-postman-plain",
                SkillType.Swagger => "devicon-swagger-plain",

                // Mobile
                SkillType.Android => "devicon-android-plain",
                SkillType.IOS => "devicon-apple-original",
                SkillType.Flutter => "devicon-flutter-plain",
                SkillType.ReactNative => "devicon-react-original",

                // Data & AI
                SkillType.MachineLearning => "fas fa-brain",
                SkillType.DeepLearning => "fas fa-network-wired",
                SkillType.TensorFlow => "devicon-tensorflow-original",
                SkillType.PyTorch => "devicon-pytorch-original",
                SkillType.DataAnalysis => "fas fa-chart-line",
                SkillType.PowerBI => "fas fa-chart-bar",

                // Testing
                SkillType.XUnit => "fas fa-vial",
                SkillType.NUnit => "fas fa-vial",
                SkillType.Selenium => "devicon-selenium-original",
                SkillType.Cypress => "devicon-cypressio-plain",

                // Architecture
                SkillType.Microservices => "fas fa-cubes",
                SkillType.CleanArchitecture => "fas fa-layer-group",
                SkillType.CQRS => "fas fa-code-branch",
                SkillType.Mediator => "fas fa-exchange-alt",
                SkillType.DesignPatterns => "fas fa-project-diagram",

                // Other
                SkillType.Linux => "devicon-linux-plain",
                SkillType.Networking => "fas fa-network-wired",
                SkillType.CyberSecurity => "fas fa-shield-alt",

                _ => "fas fa-code"
            };
        }
    }
}
