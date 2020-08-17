project=k8-dotnet
group=k8-dotnet
containerport=80
outport=30001
Image=172.20.53.96:8082/k8-dotnet

#=====================
version=tagversion
sed -i 's/project/'$project'/g' kubernetes.yml
sed -i 's/group/'$group'/g' kubernetes.yml
sed -i 's/containerport/'$containerport'/g' kubernetes.yml
sed -i 's/outport/'$outport'/g' kubernetes.yml
sed -i 's/version/'$version'/g' kubernetes.yml
sed -i 's~imageprivate~'$Image'~' kubernetes.yml